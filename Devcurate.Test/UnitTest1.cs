using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Devcurate.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFirstSeatTakenInOddSeatsRow()
        {
            Seat seat1 = new Seat();
            Seat seat2 = new Seat();
            Seat seat3 = new Seat();
            List<Seat> seats = new List<Seat>();
            seats.Add(seat1);
            seats.Add(seat2);
            seats.Add(seat3);

            Row row = new Row(seats);
            
            Assert.AreEqual(row.Book().SeatNo, 2);
        }

        [TestMethod]
        public void TestMoveRightOddSeatsRow()
        {
            Seat seat1 = new Seat();
            Seat seat2 = new Seat();
            Seat seat3 = new Seat();
            List<Seat> seats = new List<Seat>();
            seats.Add(seat1);
            seats.Add(seat2);
            seats.Add(seat3);

            Row row = new Row(seats);
            row.Book();

            Assert.AreEqual(row.Book().SeatNo, 3);
        }

        [TestMethod]
        public void TestMoveLeftOddSeatsRow()
        {
            Seat seat1 = new Seat();
            Seat seat2 = new Seat();
            Seat seat3 = new Seat();
            List<Seat> seats = new List<Seat>();
            seats.Add(seat1);
            seats.Add(seat2);
            seats.Add(seat3);

            Row row = new Row(seats);
            row.Book();
            row.Book();

            Assert.AreEqual(row.Book().SeatNo, 1);
        }

        [TestMethod]
        public void TestFirstSeatTakenInEvenSeatsRow()
        {
            Seat seat1 = new Seat();
            Seat seat2 = new Seat();
            Seat seat3 = new Seat();
            Seat seat4 = new Seat();
            List<Seat> seats = new List<Seat>();
            seats.Add(seat1);
            seats.Add(seat2);
            seats.Add(seat3);
            seats.Add(seat4);

            Row row = new Row(seats);

            Assert.AreEqual(row.Book().SeatNo, 2);
        }

        [TestMethod]
        public void TestMoveRightEvenSeatsRow()
        {
            Seat seat1 = new Seat();
            Seat seat2 = new Seat();
            Seat seat3 = new Seat();
            Seat seat4 = new Seat();
            List<Seat> seats = new List<Seat>();
            seats.Add(seat1);
            seats.Add(seat2);
            seats.Add(seat3);
            seats.Add(seat4);

            Row row = new Row(seats);
            row.Book();

            Assert.AreEqual(row.Book().SeatNo, 3);
        }

        [TestMethod]
        public void TestMoveLeftEvenSeatsRow()
        {
            Seat seat1 = new Seat();
            Seat seat2 = new Seat();
            Seat seat3 = new Seat();
            Seat seat4 = new Seat();
            List<Seat> seats = new List<Seat>();
            seats.Add(seat1);
            seats.Add(seat2);
            seats.Add(seat3);
            seats.Add(seat4);

            Row row = new Row(seats);
            row.Book();
            row.Book();
            row.Book();

            Assert.AreEqual(row.Book().SeatNo, 1);
        }

        [TestMethod]
        public void TestRowTaken()
        {
            Seat seat1 = new Seat();
            List<Seat> seats1 = new List<Seat>();
            seats1.Add(seat1);
            Row row1 = new Row(seats1);

            Seat seat2 = new Seat();
            List<Seat> seats2 = new List<Seat>();
            seats2.Add(seat2);
            Row row2 = new Row(seats2);

            List<Row> listRow = new List<Row>();
            listRow.Add(row1);
            listRow.Add(row2);

            Rows rows = new Rows(listRow);

            var book = rows.Book();

            Assert.AreEqual(book.Row, 1);
            Assert.AreEqual(book.SeatNo, 1);

            var nextbook = rows.Book();
            Assert.AreEqual(nextbook.Row, 2);
            Assert.AreEqual(book.SeatNo, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
                "All seats taken")]
        public void TestAllRowsTaken()
        {
            Seat seat1 = new Seat();
            List<Seat> seats1 = new List<Seat>();
            seats1.Add(seat1);
            Row row1 = new Row(seats1);

            List<Row> listRow = new List<Row>();
            listRow.Add(row1);

            Rows rows = new Rows(listRow);
            rows.Book();
            rows.Book();
        }
    }
}
