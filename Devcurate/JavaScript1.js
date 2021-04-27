class Seat {
    constructor(row, seatno, isseated) {
        this.row = row;
        this.seatno = seatno;
        this.isseated = isseated;
    }
}

class Row {
    constructor(seats) {
        this.seats = seats
        this.#organizeSeat();
    }

    book() {
        let i;
        for (i = this.getMiddleSeatNo(); i <= this.seats.length; i++) {
            if (this.seats[i - 1].seatno == i && this.seats[i - 1].isseated === false) {
                this.seats[i - 1].isseated = true;
                return this.seats[i - 1];
            }
        }
        for (i = this.getMiddleSeatNo() - 1; i >= 1; i--) {
            if (this.seats[i - 1].seatno == i && this.seats[i - 1].isseated === false) {
                this.seats[i - 1].isseated = true;
                return this.seats[i - 1];
            }
        }
        return null;
    }

    getrowno() {
        return this.rowno;
    }

    setrowno(value) {
        this.rowno = value;
        let i;
        for (i = 0; i < this.seats.length; i++) {
            this.seats[i].row = value;
        }
    }

    #organizeSeat() {
        let i;
        for (i = 0; i < this.seats.length; i++) {
            this.seats[i].seatno = i + 1;
            this.seats[i].isseated = false;
        }
    }

    getMiddleSeatNo() {
        return Math.ceil(this.seats.length / 2);
    }
}

class Rows {
    constructor(rows) {
        this.rows = rows;
        this.#organizerow();
    }

    book() {
        let i;
        for (i = 1; i <= this.rows.length; i++) {
            const seat = this.rows[i - 1].book();
            if (seat != null) {
                return seat;
            }
        }
        throw 'All seats taken';
    }

    #organizerow() {
        let i;
        for (i = 0; i < this.rows.length; i++) {
            this.rows[i].setrowno(i + 1);
        }
    }
}
