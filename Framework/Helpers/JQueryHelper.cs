namespace Framework.Helpers
{
    public class JQueryHelper : OpenQA.Selenium.By
    {
        public static JQueryBy jQuery(string selector)
        {
            return new JQueryBy("(\"" + selector + "\")");
        }

        public class JQueryBy
        {
            public string Selector
            {
                get;
                set;
            }

            public JQueryBy(string selector)
            {
                this.Selector = selector;
            }

            #region -----Filtering----

            public JQueryBy Eq(int index)
            {
                return Function("eq", index.ToString());
            }

            public JQueryBy First()
            {
                return Function("first");
            }

            public JQueryBy Last()
            {
                return Function("last");
            }
            #endregion

            private JQueryBy Function(string func, string selector = "", string additionalArg = "")
            {
                //Add quotes to selector
                if (selector != "")
                    selector = "\"" + selector + "\"";

                //Add additional paramater
                if (additionalArg != "")
                    selector += ",\"" + additionalArg + "\"";

                //Add either: .func() or .func("selector") to original selector
                return new JQueryBy(this.Selector + "." + func + "(" + selector + ")");
            }
        }
    }
}
