using BenchmarkDotNet.Running;
using TensorDemo;

BenchmarkRunner.Run<Benchmarks>();

// BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2033) (Hyper-V)
// Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 16 logical and 8 physical cores
// .NET SDK 9.0.100-rc.2.24474.11
//   [Host]     : .NET 9.0.0 (9.0.24.47305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
//   DefaultJob : .NET 9.0.0 (9.0.24.47305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
//
// | Method            | InputSize | Mean          | Error       | StdDev      |
// |------------------ |---------- |--------------:|------------:|------------:|
// | SumScalar         | 4         |      2.960 ns |   0.0143 ns |   0.0127 ns |
// | SumScalarUnrolled | 4         |      1.486 ns |   0.0062 ns |   0.0055 ns |
// | SumVector128      | 4         |      1.180 ns |   0.0081 ns |   0.0067 ns |
// | SumVector256      | 4         |      1.498 ns |   0.0061 ns |   0.0057 ns |
// | SumVector512      | 4         |      2.682 ns |   0.0062 ns |   0.0058 ns |
// | SumTensor         | 4         |      2.632 ns |   0.0064 ns |   0.0060 ns |
// | SumScalar         | 128       |     86.945 ns |   0.1324 ns |   0.1239 ns |
// | SumScalarUnrolled | 128       |     92.755 ns |   0.0840 ns |   0.0745 ns |
// | SumVector128      | 128       |     20.166 ns |   0.1200 ns |   0.1123 ns |
// | SumVector256      | 128       |     11.102 ns |   0.0623 ns |   0.0553 ns |
// | SumVector512      | 128       |      7.777 ns |   0.0289 ns |   0.0271 ns |
// | SumTensor         | 128       |      8.592 ns |   0.0298 ns |   0.0279 ns |
// | SumScalar         | 1024      |  1,115.218 ns |   0.7427 ns |   0.6202 ns |
// | SumScalarUnrolled | 1024      |  1,129.649 ns |   0.6522 ns |   0.5781 ns |
// | SumVector128      | 1024      |    254.831 ns |   0.2248 ns |   0.1993 ns |
// | SumVector256      | 1024      |    107.064 ns |   0.0612 ns |   0.0511 ns |
// | SumVector512      | 1024      |     52.923 ns |   0.0640 ns |   0.0568 ns |
// | SumTensor         | 1024      |     50.444 ns |   0.0854 ns |   0.0799 ns |
// | SumScalar         | 65536     | 75,686.094 ns |  51.1695 ns |  45.3604 ns |
// | SumScalarUnrolled | 65536     | 76,128.167 ns | 378.1080 ns | 335.1829 ns |
// | SumVector128      | 65536     | 18,961.566 ns |  47.8645 ns |  42.4306 ns |
// | SumVector256      | 65536     |  9,467.888 ns |  19.9630 ns |  17.6967 ns |
// | SumVector512      | 65536     |  5,240.605 ns |   7.0237 ns |   6.2263 ns |
// | SumTensor         | 65536     |  4,849.931 ns |  12.3512 ns |  11.5533 ns |

// BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2152)
// AMD Ryzen 9 7950X, 1 CPU, 32 logical and 16 physical cores
// .NET SDK 9.0.100-rc.2.24474.11
//   [Host]     : .NET 9.0.0 (9.0.24.47305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
//   DefaultJob : .NET 9.0.0 (9.0.24.47305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
//
// | Method            | InputSize | Mean           | Error       | StdDev      |
// |------------------ |---------- |---------------:|------------:|------------:|
// | SumScalar         | 4         |      0.8285 ns |   0.0253 ns |   0.0211 ns |
// | SumScalarUnrolled | 4         |      0.9990 ns |   0.0365 ns |   0.0342 ns |
// | SumVector128      | 4         |      0.9890 ns |   0.0389 ns |   0.0628 ns |
// | SumVector256      | 4         |      0.9408 ns |   0.0327 ns |   0.0783 ns |
// | SumVector512      | 4         |      1.2794 ns |   0.0428 ns |   0.0420 ns |
// | SumTensor         | 4         |      1.5139 ns |   0.0321 ns |   0.0268 ns |
// | SumScalar         | 128       |     45.7539 ns |   0.5454 ns |   0.5102 ns |
// | SumScalarUnrolled | 128       |     43.2030 ns |   0.7756 ns |   0.9809 ns |
// | SumVector128      | 128       |     14.8751 ns |   0.3139 ns |   0.8048 ns |
// | SumVector256      | 128       |      7.3852 ns |   0.1670 ns |   0.2395 ns |
// | SumVector512      | 128       |      4.7158 ns |   0.1117 ns |   0.1330 ns |
// | SumTensor         | 128       |      7.8501 ns |   0.1713 ns |   0.1904 ns |
// | SumScalar         | 1024      |    549.7889 ns |  10.8114 ns |  14.4329 ns |
// | SumScalarUnrolled | 1024      |    530.7959 ns |   4.6142 ns |   3.8531 ns |
// | SumVector128      | 1024      |    134.6532 ns |   2.7136 ns |   5.3563 ns |
// | SumVector256      | 1024      |     62.2133 ns |   1.2024 ns |   1.4314 ns |
// | SumVector512      | 1024      |     34.1236 ns |   0.7067 ns |   1.9347 ns |
// | SumTensor         | 1024      |     25.3532 ns |   0.5241 ns |   0.8611 ns |
// | SumScalar         | 65536     | 35,932.3409 ns | 172.5170 ns | 144.0595 ns |
// | SumScalarUnrolled | 65536     | 36,147.9954 ns | 383.4897 ns | 339.9537 ns |
// | SumVector128      | 65536     |  9,045.0816 ns |  47.3639 ns |  39.5510 ns |
// | SumVector256      | 65536     |  4,547.2353 ns |  73.1348 ns |  64.8321 ns |
// | SumVector512      | 65536     |  2,313.7592 ns |  39.8624 ns |  42.6523 ns |
// | SumTensor         | 65536     |  2,285.7957 ns |  45.6016 ns |  56.0028 ns |