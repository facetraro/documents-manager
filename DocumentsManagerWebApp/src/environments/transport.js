"use strict";
var Transport = (function () {
    function Transport(id, startDate, endDate, carrierId, lotsIds, state) {
        this.Id = id;
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.CarrierId = carrierId;
        this.LotIds = lotsIds;
        this.State = state;
        this.Selected = false;
    }
    return Transport;
}());
exports.Transport = Transport;
//# sourceMappingURL=transport.js.map