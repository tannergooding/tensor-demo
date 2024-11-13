using System.Numerics.Tensors;
using System.Runtime.Intrinsics;

namespace TensorDemo;

#pragma warning disable SYSLIB5001

public static class Algorithms
{
    public static float SumScalar(ReadOnlySpan<float> values)
    {
        float result = 0.0f;

        foreach (var value in values)
        {
            result += value;
        }

        return result;
    }

    public static float SumScalarUnrolled(ReadOnlySpan<float> values)
    {
        float result = 0.0f;

        int remainder = values.Length % 4;
        int unrollLimit = values.Length - remainder;

        int index = 0;

        while (index < unrollLimit)
        {
            result += values[index++];
            result += values[index++];
            result += values[index++];
            result += values[index++];
        }

        switch (remainder)
        {
            case 3:
            {
                result += values[index++];
                goto case 2;
            }

            case 2:
            {
                result += values[index++];
                goto case 1;
            }

            case 1:
            {
                result += values[index++];
                goto default;
            }

            default:
            {
                return result;
            }
        }
    }

    public static float SumVector128(ReadOnlySpan<float> values)
    {
        Vector128<float> vresult = Vector128<float>.Zero;

        int remainder = values.Length % Vector128<float>.Count;
        int unrollLimit = values.Length - remainder;

        int index = 0;

        while (index < unrollLimit)
        {
            vresult += Vector128.LoadUnsafe(in values[0], (uint)index);
            index += Vector128<float>.Count;
        }

        float result = Vector128.Sum(vresult);

        switch (remainder)
        {
            case 3:
            {
                result += values[index++];
                goto case 2;
            }

            case 2:
            {
                result += values[index++];
                goto case 1;
            }

            case 1:
            {
                result += values[index++];
                goto default;
            }

            default:
            {
                return result;
            }
        }
    }

    public static float SumVector256(ReadOnlySpan<float> values)
    {
        ReadOnlySpan<float> values = _values;
        Vector256<float> vresult = Vector256<float>.Zero;

        int remainder = values.Length % Vector256<float>.Count;
        int unrollLimit = values.Length - remainder;

        int index = 0;

        while (index < unrollLimit)
        {
            vresult += Vector256.LoadUnsafe(in values[0], (uint)index);
            index += Vector256<float>.Count;
        }

        float result = Vector256.Sum(vresult);

        switch (remainder)
        {
            case 7:
            {
                result += Vector128.Sum(Vector128.LoadUnsafe(in values[0], (uint)index));
                index += Vector128<float>.Count;
                goto case 3;
            }

            case 6:
            {
                result += Vector128.Sum(Vector128.LoadUnsafe(in values[0], (uint)index));
                index += Vector128<float>.Count;
                goto case 2;
            }

            case 5:
            {
                result += Vector128.Sum(Vector128.LoadUnsafe(in values[0], (uint)index));
                index += Vector128<float>.Count;
                goto case 1;
            }

            case 4:
            {
                result += Vector128.Sum(Vector128.LoadUnsafe(in values[0], (uint)index));
                index += Vector128<float>.Count;
                goto default;
            }

            case 3:
            {
                result += values[index++];
                goto case 2;
            }

            case 2:
            {
                result += values[index++];
                goto case 1;
            }

            case 1:
            {
                result += values[index++];
                goto default;
            }

            default:
            {
                return result;
            }
        }
    }

    public static float SumVector512(ReadOnlySpan<float> values)
    {
        Vector512<float> vresult = Vector512<float>.Zero;

        int remainder = values.Length % Vector512<float>.Count;
        int unrollLimit = values.Length - remainder;

        int index = 0;

        while (index < unrollLimit)
        {
            vresult += Vector512.LoadUnsafe(in values[0], (uint)index);
            index += Vector512<float>.Count;
        }

        float result = Vector512.Sum(vresult);

        switch (remainder)
        {
            case 15:
            {
                result += Vector256.Sum(Vector256.LoadUnsafe(in values[0], (uint)index));
                index += Vector256<float>.Count;
                goto case 7;
            }

            case 14:
            {
                result += Vector256.Sum(Vector256.LoadUnsafe(in values[0], (uint)index));
                index += Vector256<float>.Count;
                goto case 6;
            }

            case 13:
            {
                result += Vector256.Sum(Vector256.LoadUnsafe(in values[0], (uint)index));
                index += Vector256<float>.Count;
                goto case 5;
            }

            case 12:
            {
                result += Vector256.Sum(Vector256.LoadUnsafe(in values[0], (uint)index));
                index += Vector256<float>.Count;
                goto case 4;
            }

            case 11:
            {
                result += Vector256.Sum(Vector256.LoadUnsafe(in values[0], (uint)index));
                index += Vector256<float>.Count;
                goto case 3;
            }

            case 10:
            {
                result += Vector256.Sum(Vector256.LoadUnsafe(in values[0], (uint)index));
                index += Vector256<float>.Count;
                goto case 2;
            }

            case 9:
            {
                result += Vector256.Sum(Vector256.LoadUnsafe(in values[0], (uint)index));
                index += Vector256<float>.Count;
                goto case 1;
            }

            case 8:
            {
                result += Vector256.Sum(Vector256.LoadUnsafe(in values[0], (uint)index));
                index += Vector256<float>.Count;
                goto default;
            }

            case 7:
            {
                result += Vector128.Sum(Vector128.LoadUnsafe(in values[0], (uint)index));
                index += Vector128<float>.Count;
                goto case 3;
            }

            case 6:
            {
                result += Vector128.Sum(Vector128.LoadUnsafe(in values[0], (uint)index));
                index += Vector128<float>.Count;
                goto case 2;
            }

            case 5:
            {
                result += Vector128.Sum(Vector128.LoadUnsafe(in values[0], (uint)index));
                index += Vector128<float>.Count;
                goto case 1;
            }

            case 4:
            {
                result += Vector128.Sum(Vector128.LoadUnsafe(in values[0], (uint)index));
                index += Vector128<float>.Count;
                goto default;
            }

            case 3:
            {
                result += values[index++];
                goto case 2;
            }

            case 2:
            {
                result += values[index++];
                goto case 1;
            }

            case 1:
            {
                result += values[index++];
                goto default;
            }

            default:
            {
                return result;
            }
        }
    }

    public static float SumTensorPrimitives(ReadOnlySpan<float> values)
    {
        return TensorPrimitives.Sum(values);
    }

    public static float SumTensor(ReadOnlySpan<float> values)
    {
        var tensor = new ReadOnlyTensorSpan<float>(values, [], []);
        return Tensor.Sum<float>(tensor);
    }
}
