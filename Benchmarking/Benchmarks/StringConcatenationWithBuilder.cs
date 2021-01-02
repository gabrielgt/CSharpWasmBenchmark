﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    public class StringConcatenationWithBuilder : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000000, 2000000, 3000000, 4000000, 5000000, 6000000, 7000000, 8000000, 9000000, 10000000 };

        public override string InitializationDescription => "";
        public override string BenchmarkDescription => "Concatenates a single character to a string a certain number of times using a StringBuilder.";

        public override string ResultDescription => "The middle character of the concatenated string.";
        public override string ParameterDescription => "The number of characters to concatenate.";

        public int CharCount = 0;
        public string Characters = "";

        public override void Initialize(int parameter)
        {
            CharCount = (int)parameter;
            Characters = "abcdefghijklmnopqrstuvwxyz";
        }

        public override object Execute()
        {
            var res = new StringBuilder();

            for (var i = 0; i < CharCount; i++) 
            {
                res.Append(Characters[i % Characters.Length]);
            }

            return res.ToString()[CharCount / 2];
        }
    }
}
