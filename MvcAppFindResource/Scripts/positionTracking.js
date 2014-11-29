/// <reference path="jquery-2.1.1.js" />
/// <reference path="jquery-2.1.1.intellisense.js" />
var position_tracking = function () {
    var dataAccess = function () {
        var getPositionByKey = function (callbacks, getPositionUrl) {
            $.ajax({
                url: getPositionUrl,
                dataType: 'json',
                type: 'GET',
                async: false,
                contentType: 'application/json; charset=utf-8',
                //data: destination,
                success: function (result) {
                    //sample: {"Id":1,"keyName":"123456789","Lat":37.772323,"Lng":-122.214897,"dateStamp":"2014-11-17T18:30:24.22"}
                    callbacks.success(result);
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    callbacks.error(jqXhr, textStatus, errorThrown);
                }
            });
        };

        return {
            getPositionByKey: getPositionByKey
        };

    };

    var da = dataAccess();

    var getPositionByKey = function (keyName) {
        var pos = { Lat: 0.0, Lng: 0.0 };

        var callbackGetPositionByKey = {
            success: function (results) {
                console.log(results.id);
                pos.Lat = results.Lat;
                pos.Lng = results.Lng;
            },
            error:
                function (jqXhr, textStatus, errorThrown) {
                    console.log("error get getPositionByKey");
                }
        };

        var getPositionUrl = "/api/values/" + keyName;

        da.getPositionByKey(callbackGetPositionByKey, getPositionUrl);
        /// <reference path="jquery-2.1.1.js" />
        /// <reference path="jquery-2.1.1.intellisense.js" />
        var position_tracking = function () {
            var dataAccess = function () {
                var getPositionByKey = function (callbacks, getPositionUrl) {
                    $.ajax({
                        url: getPositionUrl,
                        dataType: 'json',
                        type: 'GET',
                        async: false,
                        contentType: 'application/json; charset=utf-8',
                        //data: destination,
                        success: function (result) {
                            //sample: {"Id":1,"keyName":"123456789","Lat":37.772323,"Lng":-122.214897,"dateStamp":"2014-11-17T18:30:24.22"}
                            callbacks.success(result);
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            callbacks.error(jqXhr, textStatus, errorThrown);
                        }
                    });
                };

                var savePosition = function (callbacks, position) {
                    $.ajax({
                        url: "/api/values/insert/",
                        dataType: 'json',
                        type: 'GET',
                        async: false,
                        contentType: 'application/json; charset=utf-8',
                        data: position, // format:{"Id":1,"keyName":"123456789","Lat":37.772323,"Lng":-122.214897,"dateStamp":"2014-11-17T18:30:24.22"}
                        success: function (result) {
                            //sample: {"Id":1,"keyName":"123456789","Lat":37.772323,"Lng":-122.214897,"dateStamp":"2014-11-17T18:30:24.22"}
                            callbacks.success(result);
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            callbacks.error(jqXhr, textStatus, errorThrown);
                        }
                    });
                };

                return {
                    getPositionByKey: getPositionByKey,
                    savePosition: savePosition
                };

            };

            var da = dataAccess();

            var savePosition = function (position) {
                var result = 1;
                var callbackSavePosition = {
                    success: function (results) {
                        //process successful save 
                        result = 1;
                        console.log("position saved");
                    },
                    error:
                        function (jqXhr, textStatus, errorThrown) {
                            result = 0;
                            console.log("error get getPositionByKey");
                        }

                };

                da.savePosition(callbackSavePosition, position);

                return result;
            };

            var getPositionByKey = function (keyName) {
                var pos = { Lat: 0.0, Lng: 0.0 };

                var callbackGetPositionByKey = {
                    success: function (results) {
                        console.log(results.id);
                        pos.Lat = results.Lat;
                        pos.Lng = results.Lng;
                    },
                    error:
                        function (jqXhr, textStatus, errorThrown) {
                            console.log("error get getPositionByKey");
                        }
                };

                var getPositionUrl = "/api/values/get/" + keyName;

                da.getPositionByKey(callbackGetPositionByKey, getPositionUrl);

                return pos;
            };


            return {
                dataAccess: dataAccess,
                getPositionByKey: getPositionByKey,
                savePosition: savePosition
            };

        }



        return pos;
    };


    return {
        dataAccess: dataAccess,
        getPositionByKey: getPositionByKey
    };

}


