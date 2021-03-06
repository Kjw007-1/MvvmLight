using System;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        public bool CleanupWasCalled
        {
            get;
            private set;
        }

        public const string ReceivedContentPropertyName = "ReceivedContent";

        private string _receivedContent;

        public string ReceivedContent
        {
            get
            {
                return _receivedContent;
            }

            private set
            {
                if (_receivedContent == value)
                {
                    return;
                }

                _receivedContent = value;
                RaisePropertyChanged(ReceivedContentPropertyName);
            }
        }

        public const string LastChanged1PropertyName = "LastChanged1";

        private DateTime _lastChanged1 = DateTime.MaxValue;

        public DateTime LastChanged1
        {
            get
            {
                return _lastChanged1;
            }

            set
            {
                if (_lastChanged1 == value)
                {
                    return;
                }

#if !PORTABLE && !SL4
                RaisePropertyChanging(LastChanged1PropertyName);
#endif
                var oldValue = _lastChanged1;
                _lastChanged1 = value;

                // Update bindings and broadcast change using GalaSoft.Utility.Messenging
                RaisePropertyChanged(LastChanged1PropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        /// The <see cref="LastChanged2" /> property's name.
        /// </summary>
        public const string LastChanged2PropertyName = "LastChanged2";

        private DateTime _lastChanged2 = DateTime.MaxValue;

        /// <summary>
        /// Gets the LastChanged2 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime LastChanged2
        {
            get
            {
                return _lastChanged2;
            }

            set
            {
                if (_lastChanged2 == value)
                {
                    return;
                }

#if !PORTABLE && !SL4
                RaisePropertyChanging(LastChanged2PropertyName);
#endif
                _lastChanged2 = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(LastChanged2PropertyName);
            }
        }

        /// <summary>
        /// The <see cref="TestProperty1" /> property's name.
        /// </summary>
        public const string TestProperty1PropertyName = "TestProperty1";

        private string _test1 = string.Empty;

        /// <summary>
        /// Gets the TestProperty1 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TestProperty1
        {
            get
            {
                return _test1;
            }

            set
            {
                if (_test1 == value)
                {
                    return;
                }

                _test1 = value;
                RaisePropertyChanged(TestProperty1PropertyName);
            }
        }

        /// <summary>
        /// The <see cref="TestProperty2" /> property's name.
        /// </summary>
        public const string TestProperty2PropertyName = "TestProperty2";

        private string _test2 = string.Empty;

        /// <summary>
        /// Gets the TestProperty2 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TestProperty2
        {
            get
            {
                return _test2;
            }

            set
            {
                if (_test2 == value)
                {
                    return;
                }

                _test2 = value;
                RaisePropertyChanged(TestProperty2PropertyName);
            }
        }

#if CMNATTR
        /// <summary>
        /// The <see cref="TestPropertyWithCallerMemberName" /> property's name.
        /// </summary>
        public const string TestPropertyWithCallerMemberNamePropertyName = "TestPropertyWithCallerMemberName";

        private string _testPropertyWithCallerMemberName;

        /// <summary>
        /// Sets and gets the TestPropertyWithCallerMemberName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TestPropertyWithCallerMemberName
        {
            get
            {
                return _testPropertyWithCallerMemberName;
            }

            set
            {
                if (_testPropertyWithCallerMemberName == value)
                {
                    return;
                }

                //RaisePropertyChanging();
                _testPropertyWithCallerMemberName = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The <see cref="TestPropertyWithCallerMemberNameAndBroadcast" /> property's name.
        /// </summary>
        public const string TestPropertyWithCallerMemberNameAndBroadcastPropertyName = "TestPropertyWithCallerMemberNameAndBroadcast";

        private string _testPropertyWithCallerMemberNameAndBroadcast;

        /// <summary>
        /// Sets and gets the TestPropertyWithCallerMemberNameAndBroadcast property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public string TestPropertyWithCallerMemberNameAndBroadcast
        {
            get
            {
                return _testPropertyWithCallerMemberNameAndBroadcast;
            }

            set
            {
                if (_testPropertyWithCallerMemberNameAndBroadcast == value)
                {
                    return;
                }

                //RaisePropertyChanging();
                var oldValue = _testPropertyWithCallerMemberNameAndBroadcast;
                _testPropertyWithCallerMemberNameAndBroadcast = value;
                RaisePropertyChanged(oldValue: oldValue, newValue: value, broadcast: true);
            }
        }

        /// <summary>
        /// The <see cref="TestPropertyWithCallerMemberNameAndSet" /> property's name.
        /// </summary>
        public const string TestPropertyWithCallerMemberNameAndSetPropertyName = "TestPropertyWithCallerMemberNameAndSet";

        private string _testPropertyWithCallerMemberNameAndSet;

        /// <summary>
        /// Sets and gets the TestPropertyWithCallerMemberNameAndSet property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TestPropertyWithCallerMemberNameAndSet
        {
            get
            {
                return _testPropertyWithCallerMemberNameAndSet;
            }

            set
            {
                Set(ref _testPropertyWithCallerMemberNameAndSet, value);
            }
        }


        /// <summary>
        /// The <see cref="TestPropertyWithCallerMemberNameAndSetAndBroadcast" /> property's name.
        /// </summary>
        public const string TestPropertyWithCallerMemberNameAndSetAndBroadcastPropertyName = "TestPropertyWithCallerMemberNameAndSetAndBroadcast";

        private string _testPropertyWithCallerMemberNameAndSetAndBroadcast;

        /// <summary>
        /// Sets and gets the TestPropertyWithCallerMemberNameAndSetAndBroadcast property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TestPropertyWithCallerMemberNameAndSetAndBroadcast
        {
            get
            {
                return _testPropertyWithCallerMemberNameAndSetAndBroadcast;
            }

            set
            {
                Set(ref _testPropertyWithCallerMemberNameAndSetAndBroadcast, value, true);
            }
        }
#endif

#if SILVERLIGHT
        public void HandleStringMessage(string message)
#else
        internal void HandleStringMessage(string message)
#endif
        {
            ReceivedContent = message;
        }

        public TestViewModel()
        {
            
        }

        public TestViewModel(IMessenger messenger)
            : base(messenger)
        {
        }

        public override void Cleanup()
        {
            CleanupWasCalled = true;
            base.Cleanup();
        }

        public void RaiseEmptyPropertyChanged()
        {
            RaisePropertyChanged(string.Empty);
        }

        public void RaiseEmptyPropertyChanged(string value1, string value2)
        {
            _test1 = value1;
            _test2 = value2;

            RaisePropertyChanged(string.Empty);
        }

        public void RaiseNullPropertyChanged()
        {
            RaisePropertyChanged(null);
        }

        public void RaiseNullPropertyChanged(string value1, string value2)
        {
            _test1 = value1;
            _test2 = value2;

            RaisePropertyChanged(null);
        }

        public void RaiseEmptyPropertyChangedWithBroadcast(string value1, string value2)
        {
            // This should fail
            var oldValue1 = _test1;

            _test1 = value1;
            _test2 = value2;

            RaisePropertyChanged(string.Empty, oldValue1, value1, true);
        }

        public IMessenger GetMessengerInstance()
        {
            return MessengerInstance;
        }
    }
}