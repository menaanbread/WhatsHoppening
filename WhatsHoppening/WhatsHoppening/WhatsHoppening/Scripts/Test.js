var Test = (function () {
    function Test(message) {
        this.message = message;
        this._message = message;
    }
    return Test;
})();
var test = new Test("this is my test message");
document.body.innerHTML = test._message;
//# sourceMappingURL=Test.js.map