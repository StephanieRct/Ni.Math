namespace Ni.Mathematics
{
    public interface INearEquatable<T> : INearEquatable<T, float>
    {
    }

    public interface INearEquatable<TOther, TPrecision>
    {
        public bool NearEquals(TOther o, TPrecision margin);
    }

    public interface INormalizable<TPrime>
    {
        TPrime Normalized { get; }
    }

    public interface IInvertible<TPrime>
    {
        TPrime Inversed { get; }
    }

    public interface IMultipliable<TOther> : IMultipliable<TOther, TOther>
    {
    }

    public interface IMultipliable<TOther, TPrime>
    {
        /// <summary>
        /// Transformation order: Right to Left
        /// </summary>
        TPrime Mul(TOther o);
    }

    public interface IDividable<TOther> : IDividable<TOther, TOther>
    {
    }

    public interface IDividable<TOther, TPrime>
    {
        /// <summary>
        /// Transformation order: Right to Left
        /// </summary>
        TPrime Div(TOther o);
    }
}