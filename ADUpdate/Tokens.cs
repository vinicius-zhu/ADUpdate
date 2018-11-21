namespace ADUpdate
{
    public class ComparationToken : Token
    {
    }

    public class EqualityToken : ComparationToken
    {
    }

    public class InequalityToken : ComparationToken
    {
    }

    public class GreaterThanToken : InequalityToken
    {
    }

    public class LesserThanToken : InequalityToken
    {
    }

    public class GreaterThanOrEqualToken : InequalityToken
    {
    }

    public class LesserThanOrEqualToken : InequalityToken
    {
    }

    public class EqualToken : EqualityToken
    {
    }

    public class NotEqualToken : EqualityToken
    {
    }

    public class OperandToken : Token
    {
    }
    public class OrToken : OperandToken
    {
    }

    public class AndToken : OperandToken
    {
    }

    public class BooleanValueToken : Token
    {
    }

    public class FalseToken : BooleanValueToken
    {
    }

    public class TrueToken : BooleanValueToken
    {
    }

    public class ParenthesisToken : Token
    {
    }

    public class ClosedParenthesisToken : ParenthesisToken
    {
    }

    public class OpenParenthesisToken : ParenthesisToken
    {
    }

    public class NegationToken : Token
    {
    }

    public abstract class Token
    {
    }
}
