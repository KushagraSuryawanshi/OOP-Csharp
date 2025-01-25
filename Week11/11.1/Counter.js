class Counter {
    constructor(name) {
        this._name = name;
        this._count = 0;
    }

    get name() {
        return this._name;
    }

    set name(value) {
        this._name = value;
    }

    get ticks() {
        return this._count;
    }

    increment() {
        try {
            this._count++;
        } catch (e) {
            console.error("Overflow detected: " + e.message);
        }
    }

    reset() {
        this._count = 0;
    }

    resetByDefault() {
        // JavaScript uses floating point numbers, overflow is not an issue in the same way
        this._count = 2147483647; // Use max 32-bit int value instead
    }
}
