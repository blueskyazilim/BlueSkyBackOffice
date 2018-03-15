namespace BlueSky.Core.DesignByContract.Constraints
{
    using Helpers;
    using System;
    using System.Diagnostics;
    using System.Linq;

    internal class ConstraintCheckHelper : IHelper
    {
        public void AssertConstraintIsSatisfied(
            object value,
            IConstraint constraint,
            string exceptionMessage,
            bool preConditionCheck)
        {
            if (!constraint.IsSatisfiedBy(value))
            {
                var blueSkyMiniStackTrace = string.Join("/", new StackTrace(1).GetFrames()
                    .Select(x => x.GetMethod())
                    .TakeWhile(x => x.DeclaringType != null && x.DeclaringType.Namespace != null && x.DeclaringType.Namespace.StartsWith("BlueSky"))
                    .Select(x => $"{x.DeclaringType.Namespace}:{x.Name}"));

                exceptionMessage = exceptionMessage != null ? string.Concat(exceptionMessage, "\r\n\r\n") : null;
                var valuestr = value == null ? "null" : $"'{value}' ({value.GetType().Name})";

                var message = $"{exceptionMessage}Constraint not satisfied: {constraint}\r\nValue: {valuestr}\r\nStack Trace: {blueSkyMiniStackTrace}";

                if (preConditionCheck)
                {
                    throw new PreConditionException(message);
                }
                else
                {
                    throw new PostConditionException(message);
                }
            }
        }
    }
}
