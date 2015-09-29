//------------------------------------------------------------------------------
// <copyright file="MetaDslxLanguagePackage.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using System.Collections.Generic;
using Microsoft.VisualStudio.Package;

namespace MetaDslx.VisualStudio
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [ProvideServiceAttribute(typeof(MetaGeneratorLanguageService), ServiceName = MetaGeneratorLanguageConfig.LanguageServiceName)]
    [ProvideLanguageExtension(typeof(MetaGeneratorLanguageService), MetaGeneratorLanguageConfig.FileExtension)]
    [ProvideLanguageServiceAttribute(typeof(MetaGeneratorLanguageService), MetaGeneratorLanguageConfig.LanguageName, 0,
        RequestStockColors = false, EnableCommenting = true)]
    [ProvideServiceAttribute(typeof(MetaModelLanguageService), ServiceName = MetaModelLanguageConfig.LanguageServiceName)]
    [ProvideLanguageExtension(typeof(MetaModelLanguageService), MetaModelLanguageConfig.FileExtension)]
    [ProvideLanguageServiceAttribute(typeof(MetaModelLanguageService), MetaModelLanguageConfig.LanguageName, 1,
        RequestStockColors = false, EnableCommenting = true)]
    [ProvideServiceAttribute(typeof(AnnotatedAntlr4LanguageService), ServiceName = AnnotatedAntlr4LanguageConfig.LanguageServiceName)]
    [ProvideLanguageExtension(typeof(AnnotatedAntlr4LanguageService), AnnotatedAntlr4LanguageConfig.FileExtension)]
    [ProvideLanguageServiceAttribute(typeof(AnnotatedAntlr4LanguageService), AnnotatedAntlr4LanguageConfig.LanguageName, 1,
        RequestStockColors = false, EnableCommenting = true)]
    [ProvideObject(typeof(AnnotatedAntlr4LanguageGeneratorService))]
    [ProvideObject(typeof(MetaGeneratorLanguageGeneratorService))]
    [ProvideObject(typeof(MetaModelLanguageGeneratorService))]
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [Guid(MetaDslxLanguagePackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class MetaDslxLanguagePackage : Package, IOleComponent
    {
        /// <summary>
        /// MetaDslxLanguagePackage GUID string.
        /// </summary>
        public const string PackageGuidString = "bca26545-2f40-4bc9-a57a-2bc4353d0e66";

        private Dictionary<Type, uint> componentIDs = new Dictionary<Type, uint>();

        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public MetaDslxLanguagePackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
            this.RegisterLanguageService(typeof(MetaGeneratorLanguageService));
            this.RegisterLanguageService(typeof(MetaModelLanguageService));
            this.RegisterLanguageService(typeof(AnnotatedAntlr4LanguageService));
        }

        protected override void Initialize()
        {
            // Uncomment the following two lines if the additional syntax colors do not show:
            IVsFontAndColorCacheManager mgr = this.GetService(typeof(SVsFontAndColorCacheManager)) as IVsFontAndColorCacheManager;
            mgr.ClearAllCaches();
            base.Initialize();
        }

        private void RegisterLanguageService(Type languageServiceType)
        {
            ServiceCreatorCallback callback = new ServiceCreatorCallback(
                delegate (IServiceContainer container, Type serviceType)
                {
                    if (languageServiceType == serviceType)
                    {
                        LanguageService language = (LanguageService)Activator.CreateInstance(languageServiceType);
                        language.SetSite(this);

                        // register for idle time callbacks
                        IOleComponentManager mgr = GetService(typeof(SOleComponentManager)) as IOleComponentManager;
                        uint componentID = 0;
                        if (!this.componentIDs.TryGetValue(languageServiceType, out componentID) && mgr != null)
                        {
                            OLECRINFO[] crinfo = new OLECRINFO[1];
                            crinfo[0].cbSize = (uint)Marshal.SizeOf(typeof(OLECRINFO));
                            crinfo[0].grfcrf = (uint)_OLECRF.olecrfNeedIdleTime |
                                                          (uint)_OLECRF.olecrfNeedPeriodicIdleTime;
                            crinfo[0].grfcadvf = (uint)_OLECADVF.olecadvfModal |
                                                          (uint)_OLECADVF.olecadvfRedrawOff |
                                                          (uint)_OLECADVF.olecadvfWarningsOff;
                            crinfo[0].uIdleTimeInterval = 1000;
                            int hr = mgr.FRegisterComponent(this, crinfo, out componentID);
                            this.componentIDs.Add(languageServiceType, componentID);
                        }

                        return language;
                    }
                    else
                    {
                        return null;
                    }
                });
            (this as IServiceContainer).AddService(languageServiceType, callback, true);
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                foreach (var languageServiceType in this.componentIDs.Keys)
                {
                    try
                    {
                        uint componentID = this.componentIDs[languageServiceType];
                        if (componentID != 0)
                        {
                            IOleComponentManager mgr = GetService(typeof(SOleComponentManager)) as IOleComponentManager;
                            if (mgr != null)
                            {
                                mgr.FRevokeComponent(componentID);
                            }
                            componentID = 0;
                        }
                    }
                    catch (Exception)
                    {
                        // NOP
                    }
                }
            }
            finally
            {
                try
                {
                    base.Dispose(disposing);
                }
                catch (Exception)
                {
                    // NOP
                }
            }
        }

        #region IOleComponent Members
        public int FContinueMessageLoop(uint uReason, IntPtr pvLoopData, MSG[] pMsgPeeked)
        {
            return 1;
        }

        public int FDoIdle(uint grfidlef)
        {
            List<Type> keys = new List<Type>(this.componentIDs.Keys);
            foreach (var languageServiceType in keys)
            {
                try
                {
                    LanguageService languageService = GetService(languageServiceType) as LanguageService;
                    if (languageService != null)
                    {
                        languageService.OnIdle((grfidlef & (uint)_OLEIDLEF.oleidlefPeriodic) != 0);
                    }
                }
                catch (Exception)
                {
                    // NOP
                }
            }
            return 0;
        }

        public int FPreTranslateMessage(MSG[] pMsg)
        {
            return 0;
        }

        public int FQueryTerminate(int fPromptUser)
        {
            return 1;
        }

        public int FReserved1(uint dwReserved, uint message, IntPtr wParam, IntPtr lParam)
        {
            return 1;
        }

        public IntPtr HwndGetWindow(uint dwWhich, uint dwReserved)
        {
            return IntPtr.Zero;
        }

        public void OnActivationChange(IOleComponent pic, int fSameComponent, OLECRINFO[] pcrinfo, int fHostIsActivating, OLECHOSTINFO[] pchostinfo, uint dwReserved)
        {
        }

        public void OnAppActivate(int fActive, uint dwOtherThreadID)
        {
        }

        public void OnEnterState(uint uStateID, int fEnter)
        {
        }

        public void OnLoseActivation()
        {
        }

        public void Terminate()
        {
        }
        #endregion
    }
}
