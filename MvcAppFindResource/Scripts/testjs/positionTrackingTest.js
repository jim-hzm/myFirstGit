/// <reference path="qunit-1.15.0.js" />
/// <reference path="../positionTracking.js" />

QUnit.test("position_tracking_getPositionByKey_dataAccess Test", function (assert) {
    var pt = position_tracking();

    var result = -1;

    var cb = {
        success: function () { result = 1; },
        error: function () { result = 0; }
    };

    var da = pt.dataAccess();

    da.getPositionByKey(cb, "/api/values/123456789");
    
    assert.equal(result, 1);

});

QUnit.test("position_tracking_getPositionByKey Test", function (assert) {
    var pt = position_tracking();


    var pos = pt.getPositionByKey("123456789");
    //"Lat":37.772323,"Lng":-122.214897
    assert.equal(pos.Lat, 37.772323);
    assert.equal(pos.Lng, -122.214897);

});