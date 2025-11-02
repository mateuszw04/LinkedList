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
    }
}
