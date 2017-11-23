    /// ��ʱ��������ͳ�ƴ�������ʱ��
    public class StopWatch : IDisposable
    {
        private System.Diagnostics.Stopwatch _watch;
        private List<long> _records;

        /// <summary>
        /// ˽��ʵ����һ����ʱ��
        /// </summary>
        private StopWatch()
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            _records = new List<long>();
        }

        /// <summary>
        /// ��¼һ��ʱ��ֵ
        /// </summary>
        public void Record()
        {
            _records.Add(_watch.ElapsedMilliseconds);
        }

        /// <summary>
        /// ��ȡһ����¼ֵ
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
        /// ����
        /// </summary>
        public void Dispose()
        {
            if(_watch != null) {
                _watch.Stop();
                _watch = null;
            }
        }

        /// <summary>
        /// ��̬����������һ��ʵ��
        /// </summary>
        /// <returns></returns>
        public static StopWatch New()
        {
            return new StopWatch();
        }
    }