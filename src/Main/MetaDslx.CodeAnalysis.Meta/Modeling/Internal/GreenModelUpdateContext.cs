using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class GreenModelUpdateContext
    {
        public GreenModelUpdateContext(bool newUpdater, GreenModelUpdater updater, GreenModel model)
        {
            this.NewUpdater = newUpdater;
            this.Updater = updater;
            this.OriginalModel = model;
        }

        public GreenModelUpdateContext(bool newUpdater, GreenModelUpdater updater, GreenModelGroup group)
        {
            this.NewUpdater = newUpdater;
            this.Updater = updater;
            this.OriginalModelGroup = group;
        }

        public bool NewUpdater { get; }
        public GreenModelUpdater Updater { get; }
        public GreenModel OriginalModel { get; }
        public GreenModelGroup OriginalModelGroup { get; }
    }


}
