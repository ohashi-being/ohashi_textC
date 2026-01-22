using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace Practice17_1 {
    class LineCounterProcessor : TextProcessor {
        private int _count;
        protected override void Initialize(string fname) {
            _count = 0;
        }
        protected override void Execute(string line) {
            _count++;
        }
        protected override void Terminate() {
            Console.WriteLine($"{_count}行");
        }
    }
}
