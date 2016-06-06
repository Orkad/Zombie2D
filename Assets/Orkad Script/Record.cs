using UnityEngine;
using System.Collections;

namespace Orkad
{
    public abstract class Record<T>
    {
        protected string _key;
        protected T _defaultValue;
        protected T _value;
        protected abstract T Value { get; set; }

        protected Record(string key, T defaultValue)
        {
            _key = key;
            _defaultValue = defaultValue;
        }

        public static implicit operator T(Record<T> record)
        {
            return record.Value;
        }

        public T Get()
        {
            return Value;
        }

        public void Set(T value)
        {
            Value = value;
        }
    }

    public class IntRecord : Record<int>
    {
        private bool _loaded = false;

        public IntRecord(string key, int defaultValue) : base(key, defaultValue)
        {
        }

        protected override int Value
        {
            get
            {
                if (!_loaded)
                {
                    _value = PlayerPrefs.GetInt(_key, _defaultValue);
                    _loaded = true;
                }
                return _value;
            }
            set
            {
                _loaded = true;
                if (value != _value)
                {
                    PlayerPrefs.SetInt(_key, value);
                    _value = value;
                }
            }
        }
    }

    public class FloatRecord : Record<float>
    {
        private bool _loaded = false;

        public FloatRecord(string key, float defaultValue) : base(key, defaultValue)
        {
        }

        protected override float Value
        {
            get
            {
                if (!_loaded)
                {
                    _value = PlayerPrefs.GetFloat(_key, _defaultValue);
                    _loaded = true;
                }
                return _value;
            }
            set
            {
                _loaded = true;
                if (value != _value)
                {
                    PlayerPrefs.SetFloat(_key, value);
                    _value = value;
                }
            }
        }
    }

    public class StringRecord : Record<string>
    {
        public StringRecord(string key, string defaultValue) : base(key, defaultValue)
        {
        }

        protected override string Value
        {
            get
            {
                if (_value == null)
                {
                    _value = PlayerPrefs.GetString(_key, _defaultValue);
                }
                return _value;
            }
            set
            {
                if (value != _value)
                {
                    PlayerPrefs.SetString(_key, value);
                    _value = value;
                }
            }
        }
    }

}