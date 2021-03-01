$(document).ready(function () {
    new CustomerJS();
})

/**
 * class quan ly su kien cho trang Customer
 * CreatedBy: NMHung (04/02/2020)
 * */
class CustomerJS extends BaseJS {
    constructor() {
        super();
    }
    setApiRouter() {
        this.apiRouter = "/api/v1/customers";
    }

}
