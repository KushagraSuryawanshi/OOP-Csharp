const clock = new Clock();

const runClock = () => {
    for (let i = 0; i < 25 * 3600; i++) {
        clock.tick();
        console.log(clock.getTime());
        // Simulate sleep for 5 ms (JavaScript does not have Thread.Sleep)
        const start = Date.now();
        while (Date.now() - start < 1) {}
    }
};

// Start the clock
const start = performance.now();
const memoryBefore = performance.memory.usedJSHeapSize;
runClock();
const end = performance.now();
console.log(`Execution time: ${end - start} milliseconds`);
const memoryAfter = performance.memory.usedJSHeapSize;
console.log(`Memory usage: ${memoryAfter - memoryBefore} bytes`);

