using System;

namespace CounterTask
{
    public class Clock
    {
        private Counter _hour;
        private Counter _minute;
        private Counter _second;

        public Clock()
        {
            _hour = new Counter("Hour");
            _minute = new Counter("Minute");
            _second = new Counter("Second");
        }

        public void Tick()
        {
            _second.Increment();
            if (_second.Ticks >= 60)
            {
                _second.Reset();
                _minute.Increment();
                if (_minute.Ticks >= 60)
                {
                    _minute.Reset();
                    _hour.Increment();
                    if (_hour.Ticks >= 24)
                    {
                        _hour.Reset();
                    }
                }
            }
        }

        public void Reset()
        {
            _hour.Reset();
            _minute.Reset();
            _second.Reset();
        }

        public string GetTime()
        {
            return $"{_hour.Ticks:D2}:{_minute.Ticks:D2}:{_second.Ticks:D2}";
        }
    }
}
