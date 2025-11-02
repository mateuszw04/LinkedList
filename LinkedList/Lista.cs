using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Lista
    {
        public Element head;
        public Element tail;
        public int liczbaElementów;


        public void DodajPo(Element e, int liczba)
        {

            Element newElement = new Element(liczba);


            if (liczbaElementów == 0)
            {


                this.head = newElement;

                this.tail = newElement;

                this.liczbaElementów++;

            }
            if (e == this.tail)
            {


                this.tail.next = newElement;

                newElement.prev = this.tail;

                this.tail = newElement;

                this.liczbaElementów++;


            }
            else if (e != null && e.next != null)
            {

                if (e != null)
                {
                    newElement.prev = e;
                    newElement.next = e.next;
                    e.next.prev = newElement;
                    e.next = newElement;
                    this.liczbaElementów++;
                }
                else
                {
                    throw new Exception("element nie istnieje");
                }

            }




        }

        public void DodajPo(int index, int liczba)
        {

            Element newElement = new Element(liczba);


            if (liczbaElementów == 0)
            {


                this.head = newElement;

                this.tail = newElement;

                this.liczbaElementów++;
                return;

            }

            var e = this.getElement(index);

            if (e == this.tail)
            {


                this.tail.next = newElement;

                newElement.prev = this.tail;

                this.tail = newElement;

                this.liczbaElementów++;


            }
            else if (e != null && e.next != null)
            {
                if (e != null)
                {
                    newElement.prev = e;
                    newElement.next = e.next;
                    e.next.prev = newElement;
                    e.next = newElement;

                    this.liczbaElementów++;
                } else
                {
                    throw new Exception("element nie istnieje");
                }



            }




        }

        public void DodajPrzed(int index, int liczba)
        {
            Element newElement = new Element(liczba);

            if (liczbaElementów == 0)
            {

                this.head = newElement;

                this.tail = newElement;

                this.liczbaElementów++;
                return;
            }

            var e = this.getElement(index);

            if (index > liczbaElementów || index < 0)
            {
                throw new IndexOutOfRangeException("Index " + index + " is out of range");
            }



            if (e == this.head)
            {
                // Ustaw nowy element jako glowe
                this.head = newElement;
                // Jako glowa, nowy element nie ma poprzedniego elementu
                newElement.next = e;
                e.prev = newElement;
                this.liczbaElementów++;
                return;

            }
            newElement.next = e;
            newElement.prev = e.prev;
            if (e.prev != null)
            {
                e.prev.next = newElement;
            }
            e.prev = newElement;
            this.liczbaElementów++;

        }

        public void DodajPrzed(Element e, int liczba)
        {

            Element newElement = new Element(liczba);


            if (liczbaElementów == 0)
            {

                this.head = newElement;

                this.tail = newElement;

                this.liczbaElementów++;
                return;
            }


            if (e == this.head)
            {
                // Ustaw nowy element jako glowe
                this.head = newElement;
                // Jako glowa, nowy element nie ma poprzedniego elementu
                newElement.next = e;
                e.prev = newElement;
                liczbaElementów++;
                return;

            }
            newElement.next = e;
            newElement.prev = e.prev;
            if (e.prev != null)
            {
                e.prev.next = newElement;
            }
            e.prev = newElement;
            this.liczbaElementów++;



        }

        public String ToString(string separator = "_")
        {
            if (liczbaElementów == 0)
            {
                return "";
            }
            string result = string.Empty;
            Element e = this.head;
            for (int i = 0; i < this.liczbaElementów; i++)
            {
                result += e.wartosc.ToString();
                if (e.next == null)
                {
                    return result;
                }
                result += separator;
                e = e.next;
            }
            return result;

        }
        public int[] ToArray()
        {
            if (liczbaElementów == 0)
            {
                return new int[liczbaElementów];
            }
            int[] result = new int[liczbaElementów];
            Element e = this.head;
            for (int i = 0; i < this.liczbaElementów; i++)
            {
                result[i] = e.wartosc;
                if (e.next == null)
                {
                    return result;
                }
                e = e.next;
            }
            return result;

        }
        public int getValue(int index)
        {
            if (index >= liczbaElementów || index < 0)
            {
                throw new IndexOutOfRangeException("Index " + index + " is out of range");
            }
            var e = this.head;
            for (int i = 0; i < index; i++)
            {
                e = e.next;
            }
            return e.wartosc;

        }
        public Element getElement(int index)
        {

            if (index >= liczbaElementów || index < 0)
            {
                throw new IndexOutOfRangeException("Index " + index + " is out of range");
            }
            var e = this.head;
            for (int i = 0; i < index; i++)
            {
                e = e.next;
            }
            return e;

        }
        public void set(int index, int liczba)
        {
            if (index >= liczbaElementów || index < 0)
            {
                throw new IndexOutOfRangeException("Index " + index + " is out range");
            }
            var e = this.head;
            for (int i = 0; i < index; i++)
            {
                e = e.next;
            }
            e.wartosc = liczba;

        }

        public void set(Element e, int liczba)
        {
            if (e != null)
            {
                e.wartosc = liczba;
            } else
            {
                throw new IndexOutOfRangeException("Element jest pusty");
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= liczbaElementów)
                throw new IndexOutOfRangeException($"Index {index} is out of range.");

            Element e = this.getElement(index);
            this.Remove(e);
        }
        public void Remove(Element e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            if (liczbaElementów == 0)
                throw new InvalidOperationException("lista jest pusta");

            if (e == head)
            {
                head = head.next;
                if (head != null)
                    head.prev = null;
                else
                    tail = null;
            }
            else if (e == tail)
            {
                tail = tail.prev;
                if (tail != null)
                    tail.next = null;
                else
                    head = null;
            }
            else
            {
                if (e.prev != null)
                    e.prev.next = e.next;
                if (e.next != null)
                    e.next.prev = e.prev;
            }

            liczbaElementów--;
        }

    }
}
