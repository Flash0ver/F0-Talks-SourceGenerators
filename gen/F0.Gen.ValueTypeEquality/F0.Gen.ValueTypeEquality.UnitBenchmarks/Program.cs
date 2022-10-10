using BenchmarkDotNet.Running;
using F0.Gen.ValueTypeEquality.UnitBenchmarks;

_ = BenchmarkRunner.Run<ValueTypeEqualityGeneratorUnitBenchmarks>();
