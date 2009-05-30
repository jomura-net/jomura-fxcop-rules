using System.Reflection;
using Microsoft.FxCop.Sdk;

namespace Jomura.FxCop.Rules.Web
{
    ///<summary>
    /// HttpContext.Current�̗��p�����o���Čx������FxCop���[���ł�
    ///</summary>
    public class AvoidUsingHttpContextCurrent : AbstractRule
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public AvoidUsingHttpContextCurrent()
            : base("AvoidUsingHttpContextCurrent")
        {
        }

        #region �����ƌ�n��

        TypeNode httpContextType;

        public override void BeforeAnalysis()
        {
            base.BeforeAnalysis();
            try
            {
                httpContextType = FrameworkAssemblies.SystemWeb.GetType(
                    Identifier.For("System.Web"), Identifier.For("HttpContext"));
            }
            catch (System.NullReferenceException)
            {
                // Not Reference System.Web
                // Do Nothing
            }
        }

        public override void AfterAnalysis()
        {
            httpContextType = null;
            base.AfterAnalysis();
        }

        #endregion

        public override ProblemCollection Check(Member member)
        {
            if (member is Method)
            {
                Visit(member);
            }
            return Problems;
        }

        public override void VisitMethodCall(MethodCall call)
        {
            MemberBinding mb = call.Callee as MemberBinding;
            if( mb.BoundMember.DeclaringType == httpContextType
                && mb.BoundMember.Name.Name=="get_Current" )
            {
                Problems.Add(new Problem( GetResolution() ));
            }
            base.VisitMethodCall(call);
        }
    }
}
