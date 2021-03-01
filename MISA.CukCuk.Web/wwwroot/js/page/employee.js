$(document).ready(function () {
    new EmployeeJS();
})

class EmployeeJS extends BaseJS {
    constructor() {
        super();
    }
    setApiRouter() {
        this.apiRouter = "/api/employees";
    }
}