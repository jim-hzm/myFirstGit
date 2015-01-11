/// <reference path="jquery-2.1.1.js" />
/// <reference path="jquery-2.1.1.intellisense.js" />
/// <reference path="jquery.cookie.js" />

var position_tracking = function () {
    var appPath = function () {
        //"/findloc/myloc/location.html"
        if (location.pathname.toLowerCase().indexOf("findloc") > 0)
            return "/findloc";
        return "";
    };

    var dataAccess = function () {
        var getPositionByKey = function (callbacks, getPositionUrl) {
            $.ajax({
                url: appPath() + getPositionUrl,
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
                url: appPath() +  "/api/values/insert/",
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

    var saveCurrBrowserPosition = function () {
        //information tracked: device, browser version, ip, position
        navigator.geolocation.getCurrentPosition(getLocation);
        function getLocation(location) {
            //alert(location.coords.latitude);
            //alert(location.coords.longitude);
            //alert(location.coords.accuracy);
            var position = {
                "id":
                    0,
                "keyName":
                    $.cookie("trackId"),
                "Lat":
                    location.coords.latitude,
                "Lng":
                    location.coords.longitude,
                "dateStamp":
                    (new Date()).toLocaleString()
            };

            savePosition(position);
        }
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

    var isTrackIDexists = function () {
        if ($.cookie("trackId") === undefined || $.cookie("trackId")==="")
            return false;
        return true;
    };

    var saveTrackIdToCookie = function (trackId) {
        $.cookie("trackId", trackId);
    };


   var initSimpleMark = function () {
        var pt = position_tracking();
        var pos = pt.getPositionByKey($.cookie("trackId")); //123456788, 123456789
        var myLatlng = new google.maps.LatLng(pos.Lat, pos.Lng);    //new google.maps.LatLng(43.66,-79.59);
        var mapOptions = {
            zoom: 10,
            center: myLatlng
        }
        var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
            title: 'Hello World!'
        });
    }
   return {
       initSimpleMark: initSimpleMark,
       appPath: appPath,
        isTrackIDexists: isTrackIDexists,
        saveTrackIdToCookie: saveTrackIdToCookie,
        saveCurrBrowserPosition: saveCurrBrowserPosition,
        dataAccess: dataAccess,
        getPositionByKey: getPositionByKey,
        savePosition: savePosition
    };

}


