using LinkedList;
using NUnit.Framework;
using System;
using System.Xml.Linq;

namespace LinkedListTests
{
    [TestFixture]
    public class Tests
    {
        private Lista lista;

        [SetUp]
        public void Setup()
        {
            lista = new Lista();
        }

        [Test]
        public void DodajPo_EmptyList_AddsFirstElement()
        {
            lista.DodajPo(new Element(0), 10);
            Assert.That(lista.liczbaElementów, Is.EqualTo(1));
            Assert.That(lista.head.wartosc, Is.EqualTo(10));
            Assert.That(lista.tail, Is.EqualTo(lista.head));
        }

        [Test]
        public void DodajPo_AddAfterTail_AddsCorrectly()
        {
            var e1 = new Element(5);
            lista.head = lista.tail = e1;
            lista.liczbaElementów = 1;

            lista.DodajPo(e1, 7);

            Assert.That(lista.liczbaElementów, Is.EqualTo(2));
            Assert.That(lista.tail.wartosc, Is.EqualTo(7));
            Assert.That(lista.tail, Is.EqualTo(e1.next));
            Assert.That(e1, Is.EqualTo(lista.tail.prev));
        }

        [Test]
        public void DodajPrzed_EmptyList_AddsAsHeadAndTail()
        {
            lista.DodajPrzed(0, 42);

            Assert.That(lista.liczbaElementów, Is.EqualTo(1));
            Assert.That(lista.head.wartosc, Is.EqualTo(42));
            Assert.That(lista.head, Is.EqualTo(lista.tail));
        }

        [Test]
        public void DodajPrzed_AtHead_InsertsBeforeHead()
        {
            lista.DodajPrzed(0, 10);
            lista.DodajPo(0, 20);

            lista.DodajPrzed(0, 5);

            Assert.That(lista.liczbaElementów, Is.EqualTo(3));
            Assert.That(lista.head.wartosc, Is.EqualTo(5));
            Assert.That(lista.tail.wartosc, Is.EqualTo(20));
        }

        [Test]
        public void DodajPo_AddInMiddle_PointersCorrect()
        {
            lista.DodajPrzed(0, 1);
            lista.DodajPo(0, 2);
            lista.DodajPo(0, 5);

            int[] arr = lista.ToArray();
            CollectionAssert.AreEqual(new[] { 1, 5, 2 }, arr);
        }

        [Test]
        public void getValue_ReturnsCorrectValue()
        {
            lista.DodajPrzed(0, 10);
            lista.DodajPo(0, 20);
            lista.DodajPo(1, 30);

            Assert.That(lista.getValue(1), Is.EqualTo(20));
        }

        [Test]
        public void getValue_InvalidIndex_Throws()
        {
            lista.DodajPrzed(0, 10);
            Assert.Throws<IndexOutOfRangeException>(() => lista.getValue(5));
        }

        [Test]
        public void set_ByIndex_UpdatesValue()
        {
            lista.DodajPrzed(0, 10);
            lista.DodajPo(0, 20);

            lista.set(1, 99);

            Assert.That(lista.getValue(1), Is.EqualTo(99));
        }

        [Test]
        public void set_ByElement_UpdatesValue()
        {
            lista.DodajPrzed(0, 10);
            var e = lista.getElement(0);

            lista.set(e, 123);
            Assert.That(lista.getValue(0), Is.EqualTo(123));
        }

        [Test]
        public void ToString_And_ToArray_WorkCorrectly()
        {
            lista.DodajPrzed(0, 1);
            lista.DodajPo(0, 2);
            lista.DodajPo(1, 3);

            Assert.That(lista.ToString("_"), Is.EqualTo("1_2_3"));
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, lista.ToArray());
        }

        [Test]
        public void NullSafety_NoNullPointer_WhenInsertingInValidPlaces()
        {
            lista.DodajPrzed(0, 10);
            lista.DodajPo(0, 20);
            lista.DodajPo(1, 30);
            lista.DodajPrzed(2, 25);
            lista.DodajPo(2, 27);
            Assert.DoesNotThrow(() => lista.ToString("-"));
            Assert.That(lista.liczbaElementów, Is.EqualTo(5));
        }

        [Test]
        public void Remove_ByElement_RemovesCorrectNode()
        {
            var list = new Lista();
            list.DodajPo((Element?)null, 1);
            var second = new Element(2);
            list.DodajPo(list.head, 2);
            list.DodajPo(list.tail, 3);
            list.Remove(list.head!.next!);
            var arr = list.ToArray();
            Assert.That(list.liczbaElementów, Is.EqualTo(2));
            Assert.That(arr, Is.EqualTo(new[] { 1, 3 }));
            Assert.IsNull(list.head!.next!.next);
        }

        [Test]
        public void Remove_ByIndex_RemovesCorrectNode()
        {
            var list = new Lista();
            list.DodajPo((Element?)null, 10);
            list.DodajPo(list.head, 20);
            list.DodajPo(list.tail, 30);
            list.Remove(1);
            var arr = list.ToArray();
            Assert.That(list.liczbaElementów, Is.EqualTo(2));
            Assert.That(arr, Is.EqualTo(new[] { 10, 30 }));
        }

        [Test]
        public void Remove_Head_RemovesFirstElement()
        {
            var list = new Lista();
            list.DodajPo((Element?)null, 5);
            list.DodajPo(list.head, 10);
            list.DodajPo(list.tail, 15);

            list.Remove(0);

            Assert.That(list.ToArray(), Is.EqualTo(new[] { 10, 15 }));
            Assert.That(list.liczbaElementów, Is.EqualTo(2));
            Assert.That(list.head!.wartosc, Is.EqualTo(10));
        }

        [Test]
        public void Remove_Tail_RemovesLastElement()
        {
            var list = new Lista();
            list.DodajPo((Element?)null, 5);
            list.DodajPo(list.head, 10);
            list.DodajPo(list.tail, 15);

            list.Remove(list.tail!);

            Assert.That(list.ToArray(), Is.EqualTo(new[] { 5, 10 }));
            Assert.That(list.liczbaElementów, Is.EqualTo(2));
            Assert.That(list.tail!.wartosc, Is.EqualTo(10));
        }

        [Test]
        public void Remove_InvalidIndex_ThrowsException()
        {
            var list = new Lista();
            list.DodajPo((Element?)null, 1);

            Assert.Throws<IndexOutOfRangeException>(() => list.Remove(5));
        }

        [Test]
        public void Remove_NullElement_ThrowsArgumentNullException()
        {
            var list = new Lista();
            Assert.Throws<ArgumentNullException>(() => list.Remove((Element?)null!));
        }
    }
}
