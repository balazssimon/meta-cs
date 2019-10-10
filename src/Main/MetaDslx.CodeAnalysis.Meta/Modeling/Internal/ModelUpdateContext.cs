using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class ModelUpdateContext
    {
        public ModelUpdateContext(bool newUpdater, GreenModelUpdater updater, GreenModel model)
        {
            this.NewUpdater = newUpdater;
            this.Updater = updater;
            this.OriginalModel = model;
        }

        public ModelUpdateContext(bool newUpdater, GreenModelUpdater updater, GreenModelGroup group)
        {
            this.NewUpdater = newUpdater;
            this.Updater = updater;
            this.OriginalModelGroup = group;
        }

        internal bool NewUpdater { get; }
        internal GreenModelUpdater Updater { get; }
        internal GreenModel OriginalModel { get; }
        internal GreenModelGroup OriginalModelGroup { get; }
    }


}
