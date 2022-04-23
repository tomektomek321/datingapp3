
export function createCitiesIdStringForRequest(cities) {
    let citiesString = ""

    cities.forEach(element => {
        citiesString += (element.id + "-")
    });

    citiesString = citiesString.slice(0, citiesString.length - 1);

    return citiesString;

}