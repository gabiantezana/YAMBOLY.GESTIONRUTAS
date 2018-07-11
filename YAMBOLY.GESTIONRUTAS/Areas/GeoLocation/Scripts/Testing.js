﻿//const drawingModes = Object.freeze({ drawZoneMode: 1, drawRouteMode: 2 });
const BUTTONMODE = Object.freeze({ Create: 1, Edit: 2, Remove: 3 });
const SHAPETYPE = Object.freeze({ Zone: 1, Route: 2, Client: 3 });


var colors = ['red', 'green', 'blue', 'orange', 'yellow', 'BlueViolet ', 'DarkMagenta', 'Brown ', 'Violet', 'Lime', 'GoldenRod', 'CadetBlue'];
var latLngCenterInit = new google.maps.LatLng(-12.0912651, -77.00467609999998);

var drawingManagerPolygonOptions = {
    drawingMode: google.maps.drawing.OverlayType.POLYGON,
    drawingControl: false,
    markerOptions: {
        draggable: true
    }
}

var drawingManagerMarkerOptions = {
    drawingMode: google.maps.drawing.OverlayType.MARKER,
    drawingControl: false,
    markerOptions: {
        draggable: true
    }
}

var polygonOptionsZone = {
    strokeWeight: 0.5,
    fillOpacity: 0.40,
    editable: true,
    fillColor: 'HotPink',
}

var polygonOptionsRoute = {
    strokeWeight: 0,
    fillOpacity: 0.40,
    editable: true,
    fillColor: '#FF1493',
}

function isPolygonInsidePolygon(innerPolygon, outerPolygon) {
    var pointsInside = 0;
    var pointsOutside = 0;
    innerPolygon.getPath().getArray().map(function (x) {
        (google.maps.geometry.poly.containsLocation(x, outerPolygon)) ? pointsInside++ : pointsOutside++;
    });
    return (pointsOutside > 0) ? false : true;
};

function _isPolygonIntersectedWithAnother(innerPolygon, outerPolygon) {
    var pointsInside = 0;
    var pointsOutside = 0;
    innerPolygon.getPath().getArray().map(function (x) {
        (google.maps.geometry.poly.containsLocation(x, outerPolygon)) ? pointsInside++ : pointsOutside++;
    });
    return (pointsInside > 0) ? true : false;
};

function GetPointsFromPolygon(polygon) {
    var coordinates = [];
    var message = '';
    message += "polygon points:" + "<br>";
    for (var i = 0; i < polygon.getPath().getLength(); i++) {
        coordinates.push({
            lat: polygon.getPath().getAt(i).lat(),
            lng: polygon.getPath().getAt(i).lng()
        });
    }
    return coordinates;
}

function GetZonePolygoneFromRoutePolygon(routePolygon) {
    return _.findWhere(polygonArray, { parentPolygonId: routePolygon.parentPolygonId });
}

function RemoveSelectedPolygon() {
    if (currentSelectedShape) {
        currentSelectedShape.setMap(null);
        drawingManager.setMap(null);
        editedPolygonArray = _.without(editedPolygonArray, _.findWhere(editedPolygonArray, { Id: currentSelectedShape.Id }));
    }
}

function clearSelection() {
    if (currentSelectedShape) {
        switch (currentSelectedShape.ShapeType) {
            case SHAPETYPE.Zone:
            case SHAPETYPE.Route:
                currentSelectedShape.setEditable(false);
                break;
            case SHAPETYPE.Client:
                currentSelectedShape.setDraggable(false);
                break;
            default:
                throw "Invalid shape type";
        }
        currentSelectedShape = null;
    }
}

function setSelection(shape) {
    clearSelection();
    currentSelectedShape = shape;
    switch (shape.ShapeType) {
        case SHAPETYPE.Zone:
        case SHAPETYPE.Route:
            shape.setEditable(true);
            break;
        case SHAPETYPE.Client:
            shape.setDraggable(true);
            break;
        default:
            throw "Invalid shape type";
    }
}

function GetPolygonCenter(poly) {
    var lowx,
        highx,
        lowy,
        highy,
        lats = [],
        lngs = [],
        vertices = poly.getPath();

    for (var i = 0; i < vertices.length; i++) {
        lngs.push(vertices.getAt(i).lng());
        lats.push(vertices.getAt(i).lat());
    }

    lats.sort();
    lngs.sort();
    lowx = lats[0];
    highx = lats[vertices.length - 1];
    lowy = lngs[0];
    highy = lngs[vertices.length - 1];
    center_x = lowx + ((highx - lowx) / 2);
    center_y = lowy + ((highy - lowy) / 2);
    return (new google.maps.LatLng(center_x, center_y));
}

function IsAValidShape(shape) {
    var isValid = false;
    switch (shape.ShapeType) {
        case SHAPETYPE.Zone:
            isValid = IsAValidZone(shape);
            break;
        case SHAPETYPE.Route:
            isValid = ValidateCreatedRoute(shape);
            break;
        case SHAPETYPE.Client:
            isValid = true; //TODO: Add Validation
            break;
        default:
            throw "Invalid shape type";
    }

    return isValid;

    /*/Change color for next draw in routes
    var polygonOptions = drawingManager.get('polygonOptions');
    polygonOptions.fillColor = colors[Math.floor(Math.random() * colors.length)];
    drawingManager.set('polygonOptions', polygonOptions);*/
}

function IsAValidZone(polygon) {
    //-----------------VALIDA QUE NO INTERSECTE A OTRAS ZONAS -------------------
    var isIntersected = false;
    for (var i = 0; i < editedPolygonArray.length; i++) {
        if (editedPolygonArray[i].ShapeType == SHAPETYPE.Zone) {
            isIntersected = _isPolygonIntersectedWithAnother(polygon, editedPolygonArray[i]);
            if (isIntersected) {
                break;
            }
        }
    };
    return !isIntersected;
}

function ValidateCreatedRoute(polygon) {
    var isValid = false;
    //------------VALIDA QUE ESTÉ DIBUJADO DENTRO DE SU ZONA CORRESPONDIENTE---------
    parentZone = _.findWhere(editedPolygonArray, { Id: polygon.ParentId });
    if (parentZone)
        isValid = isPolygonInsidePolygon(polygon, parentZone);
    else
        console.log("No se encontró la zona del polígono: " + polygon.ParentId + " en el array.");

    //-----------------VALIDA QUE NO INTERSECTE A NINGUNA OTRA RUTA -------------------
    if (isValid) {
        for (var i = 0; i < editedPolygonArray.length; i++) {
            if (editedPolygonArray[i].ShapeType == SHAPETYPE.rou) {
                isValid = !_isPolygonIntersectedWithAnother(polygon, editedPolygonArray[i]);
                if (isValid) {
                    break;
                }
            }
        };
    }
    return isValid;
}