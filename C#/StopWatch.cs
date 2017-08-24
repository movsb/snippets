    /// 计时器，用来统计代码运行时间
    public class StopWatch : IDisposable
    {
        private System.Diagnostics.Stopwatch _watch;
        private List<long> _records;

        /// <summary>
        /// 私有实例化一个计时器
        /// </summary>
        private StopWatch()
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            _records = new List<long>();
        }

        /// <summary>
        /// 记录一个时间值
        /// </summary>
        public void Record()
        {
            _records.Add(_watch.ElapsedMilliseconds);
        }

        /// <summary>
        /// 获取一个记录值
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long this[int i]
        {
            get
            {
                if(i == 0) {
                    return _watch.ElapsedMilliseconds;
                }
                else if(i == 1) {
                    return _records.Count >= 1
                        ? _records[0]
                        : 0;
                }
                else if(i > 1 && i <= _records.Count) {
                    return _records[i - 1] - _records[i - 2];
                } else {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if(_records.Count > 0) {
                var lst = new List<long>();
                for(var i = 1; i <= _records.Count; i++) {
                    lst.Add(this[i]);
                }
                return string.Format("{{{0}}}", string.Join(",", lst));
            }
            else {
                return string.Format("{{{0}}}", _watch.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            if(_watch != null) {
                _watch.Stop();
                _watch = null;
            }
        }

        /// <summary>
        /// 静态方法：创建一个实例
        /// </summary>
        /// <returns></returns>
        public static StopWatch New()
        {
            return new StopWatch();
        }
    }