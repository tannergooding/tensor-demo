using BenchmarkDotNet.Attributes;
using System.Numerics.Tensors;

namespace TensorDemo;

public class Benchmarks
{
    private float[] _values;

    [Params(4, 128, 1024, 65536)]
    public int InputSize;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var rng = new Random(20241023);
        var values = new float[InputSize];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = rng.NextSingle();
        }

        _values = values;
    }

    [Benchmark]
    public float SumScalar() => Algorithms.SumScalar(_values);

    [Benchmark]
    public float SumScalarUnrolled() => Algorithms.SumScalarUnrolled(_values);

    [Benchmark]
    public float SumVector128() => Algorithms.SumVector128(_values);

    [Benchmark]
    public float SumVector256() => Algorithms.SumVector256(_values);

    [Benchmark]
    public float SumVector512() => Algorithms.SumVector512(_values);

    [Benchmark]
    public float SumTensor() => TensorPrimitives.Sum(_values);
}
