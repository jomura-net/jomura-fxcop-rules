using Microsoft.FxCop.Sdk;

namespace Jomura.FxCop.Rules
{
    [System.CLSCompliant(false)]
    public abstract class AbstractRule : BaseIntrospectionRule
    {
		#region Constructors

        protected AbstractRule()
            : this("AbstractRule") 
		{
		}

        protected AbstractRule(string name)
            : base(name, "Jomura.FxCop.Rules", typeof(AbstractRule).Assembly) 
		{
		}

		#endregion
    }
}
