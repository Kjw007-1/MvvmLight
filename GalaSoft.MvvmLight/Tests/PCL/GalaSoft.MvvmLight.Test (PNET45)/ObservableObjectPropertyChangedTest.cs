using System;
using GalaSoft.MvvmLight.Test.ViewModel;

#if NEWUNITTEST
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace GalaSoft.MvvmLight.Test
{
    [TestClass]
    public class ObservableObjectPropertyChangedTest
    {
        [TestMethod]
        public void TestPropertyChangedNoBroadcast()
        {
            var receivedDateTimeLocal = DateTime.MinValue;

            var vm = new TestClassWithObservableObject();
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.LastChangedPropertyName)
                {
                    receivedDateTimeLocal = vm.LastChanged;
                }
            };

            var now = DateTime.Now;
            vm.LastChanged = now;
            Assert.AreEqual(now, vm.LastChanged);
            Assert.AreEqual(now, receivedDateTimeLocal);
        }

        [TestMethod]
        public void TestPropertyChangedNoMagicString()
        {
            var receivedDateTimeLocal = DateTime.MinValue;

            var vm = new TestClassWithObservableObject();
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "LastChangedNoMagicString")
                {
                    receivedDateTimeLocal = vm.LastChangedNoMagicString;
                }
            };

            var now = DateTime.Now;
            vm.LastChangedNoMagicString = now;
            Assert.AreEqual(now, vm.LastChangedNoMagicString);
            Assert.AreEqual(now, receivedDateTimeLocal);
        }

        [TestMethod]
        public void TestRaisePropertyChangedValidInvalidPropertyName()
        {
            var vm = new TestClassWithObservableObject();

            var receivedPropertyChanged = false;
            var invalidPropertyNameReceived = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.LastChangedPropertyName)
                {
                    receivedPropertyChanged = true;
                }
                else
                {
                    invalidPropertyNameReceived = true;
                }
            };

            vm.RaisePropertyChangedPublic(TestClassWithObservableObject.LastChangedPropertyName);

            Assert.IsTrue(receivedPropertyChanged);
            Assert.IsFalse(invalidPropertyNameReceived);

            try
            {
                vm.RaisePropertyChangedPublic(TestClassWithObservableObject.LastChangedPropertyName + "1");

#if DEBUG
                Assert.Fail("ArgumentException was expected");
#else
                Assert.IsTrue(invalidPropertyNameReceived);
#endif
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void TestSet()
        {
            var vm = new TestClassWithObservableObject();
            const int expectedValue = 1234;
            var receivedValueChanged = 0;
            //var receivedValueChanging = 0;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.PropertyWithSetPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithSet;
                }
            };

            //vm.PropertyChanging += (s, e) =>
            //{
            //    if (e.PropertyName == TestClassWithObservableObject.PropertyWithSetPropertyName)
            //    {
            //        receivedValueChanging = vm.PropertyWithSet;
            //    }
            //};

            vm.PropertyWithSet = expectedValue;
            Assert.AreEqual(expectedValue, receivedValueChanged);
            //Assert.AreEqual(-1, receivedValueChanging);
        }

        [TestMethod]
        public void TestSetWithString()
        {
            var vm = new TestClassWithObservableObject();
            const int expectedValue = 1234;
            var receivedValueChanged = 0;
            //var receivedValueChanging = 0;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.PropertyWithStringSetPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithStringSet;
                }
            };

            //vm.PropertyChanging += (s, e) =>
            //{
            //    if (e.PropertyName == TestClassWithObservableObject.PropertyWithStringSetPropertyName)
            //    {
            //        receivedValueChanging = vm.PropertyWithStringSet;
            //    }
            //};

            vm.PropertyWithStringSet = expectedValue;
            Assert.AreEqual(expectedValue, receivedValueChanged);
            //Assert.AreEqual(-1, receivedValueChanging);
        }

        [TestMethod]
        public void TestReturnValueWithSet()
        {
            var vm = new TestClassWithObservableObject();
            const int firstValue = 1234;
            var receivedValueChanged = 0;
            //var receivedValueChanging = 0;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.PropertyWithSetPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithSet;
                }
            };

            //vm.PropertyChanging += (s, e) =>
            //{
            //    if (e.PropertyName == TestClassWithObservableObject.PropertyWithSetPropertyName)
            //    {
            //        receivedValueChanging = vm.PropertyWithSet;
            //    }
            //};

            vm.PropertyWithSet = firstValue;
            //Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithSet = firstValue;
            //Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsFalse(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithSet = firstValue + 1;
            //Assert.AreEqual(firstValue, receivedValueChanging);
            Assert.AreEqual(firstValue + 1, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);
        }

        [TestMethod]
        public void TestReturnValueWithSetWithString()
        {
            var vm = new TestClassWithObservableObject();
            const int firstValue = 1234;
            var receivedValueChanged = 0;
            //var receivedValueChanging = 0;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.PropertyWithStringSetPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithStringSet;
                }
            };

            //vm.PropertyChanging += (s, e) =>
            //{
            //    if (e.PropertyName == TestClassWithObservableObject.PropertyWithStringSetPropertyName)
            //    {
            //        receivedValueChanging = vm.PropertyWithStringSet;
            //    }
            //};

            vm.PropertyWithStringSet = firstValue;
            //Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithStringSet = firstValue;
            //Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsFalse(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithStringSet = firstValue + 1;
            //Assert.AreEqual(firstValue, receivedValueChanging);
            Assert.AreEqual(firstValue + 1, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);
        }

//#if CMNATTR
//        [TestMethod]
//        public void TestCallerMemberName()
//        {
//            var instance = new TestViewModel();

//            const string value1 = "1234";
//            const string value2 = "5678";

//            instance.TestPropertyWithCallerMemberName = value1;

//            var changedWasRaised = false;

//            instance.PropertyChanged += (s, e) =>
//            {
//                if (e.PropertyName != TestViewModel.TestPropertyWithCallerMemberNamePropertyName)
//                {
//                    return;
//                }

//                var sender = (TestViewModel)s;
//                Assert.AreSame(instance, sender);

//                Assert.AreEqual(value2, instance.TestPropertyWithCallerMemberName);
//                changedWasRaised = true;
//            };

//            instance.TestPropertyWithCallerMemberName = value2;
//            Assert.IsTrue(changedWasRaised);
//        }
//        [TestMethod]
//        public void TestCallerMemberNameWithSet()
//        {
//            var instance = new TestViewModel();

//            const string value1 = "1234";
//            const string value2 = "5678";

//            instance.TestPropertyWithCallerMemberNameAndSet = value1;

//            var changedWasRaised = false;

//            instance.PropertyChanged += (s, e) =>
//            {
//                if (e.PropertyName != TestViewModel.TestPropertyWithCallerMemberNameAndSetPropertyName)
//                {
//                    return;
//                }

//                var sender = (TestViewModel)s;
//                Assert.AreSame(instance, sender);

//                Assert.AreEqual(value2, instance.TestPropertyWithCallerMemberNameAndSet);
//                changedWasRaised = true;
//            };

//            instance.TestPropertyWithCallerMemberNameAndSet = value2;
//            Assert.IsTrue(changedWasRaised);
//        }

//#endif
    }
}
