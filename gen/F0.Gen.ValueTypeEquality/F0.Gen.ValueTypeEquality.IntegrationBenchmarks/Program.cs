using BenchmarkDotNet.Running;
using F0.Gen.ValueTypeEquality.IntegrationBenchmarks;

_ = BenchmarkRunner.Run<ValueTypeBenchmarks>();
