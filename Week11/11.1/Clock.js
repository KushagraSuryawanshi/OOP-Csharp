class Clock {
    constructor() {
        this._hour = new Counter("Hour");
        this._minute = new Counter("Minute");
        this._second = new Counter("Second");
    }

    tick() {
        this._second.increment();
        if (this._second.ticks >= 60) {
            this._second.reset();
            this._minute.increment();
            if (this._minute.ticks >= 60) {
                this._minute.reset();
                this._hour.increment();
                if (this._hour.ticks >= 24) {
                    this._hour.reset();
                }
            }
        }
    }

    reset() {
        this._hour.reset();
        this._minute.reset();
        this._second.reset();
    }

    getTime() {
        return `${this._hour.ticks.toString().padStart(2, '0')}:${this._minute.ticks.toString().padStart(2, '0')}:${this._second.ticks.toString().padStart(2, '0')}`;
    }
}
