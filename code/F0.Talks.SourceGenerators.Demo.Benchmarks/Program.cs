using BenchmarkDotNet.Running;
using F0.Talks.SourceGenerators.Demo.Benchmarks;

_ = BenchmarkRunner.Run<LoggingBenchmarks>();
