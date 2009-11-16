using System;
using System.Collections;
using System.Collections.Generic;
using Pronghorn.Core;

namespace Pronghorn.Widgets
{
    public class HelloWorldWebWidget : WebWidgetBase
    {
        public override IEnumerable<T> GetModel<T>()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable GetModel()
        {
            return new[] {"one", "two", "three"};
        }
    }
}
