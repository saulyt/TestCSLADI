namespace TestCSLADI.Library
{
    public class TestDI : ITestDI
    {
        DateTime _createTime;
        public TestDI()
        {
            _createTime = DateTime.Now;
        }
        public DateTime GetCreateTime()
        {
            return _createTime;
        }
    }
}
