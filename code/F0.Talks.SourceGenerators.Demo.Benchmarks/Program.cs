using BenchmarkDotNet.Running;

_ = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
