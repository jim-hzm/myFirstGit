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

    da.getPositionByKey(cb, "/api/values/get/123456789");

    assert.equal(result, 1);

});

QUnit.test("position_tracking_savePosition Test", function (assert) {
    var pt = position_tracking();

    var position = {
        "id":
            0,
        "Lat":
            48.5121372,
        "Lng":
            -80.165364,
        "dateStamp":
            "2014-11-17T18:30:24.22"
    };

    var result = pt.savePosition(position);
    //"Lat":37.772323,"Lng":-122.214897
    assert.equal(result, 1);

});

QUnit.test("position_tracking_getPositionByKey Test", function (assert) {
    var pt = position_tracking();


    var pos = pt.getPositionByKey("123456789");
    //"Lat":37.772323,"Lng":-122.214897
    assert.equal(pos.Lat, 37.772323);
    assert.equal(pos.Lng, -122.214897);

});