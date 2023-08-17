import { IdName } from 'src/app/shared/models/IdName';
import { SearchUserReqDto } from '../models/SearchUserDto';
import { SearchUserParams } from '../models/SearchUserParams';

export function createFilterParams(params: SearchUserParams): SearchUserReqDto {
  const citiesString = createCitiesIdStringForRequest(params.cities);
  const hobbiesString = createCitiesIdStringForRequest(params.hobbies);

  return {
    gender: typeof(params.gender) == 'number' ? params.gender : parseInt(params.gender) as 1 | 0,
    maxAge: params.maxAge,
    minAge: params.minAge,
    orderBy: params.orderBy,
    cities: citiesString,
    hobbies: hobbiesString,
  };
}

export function createCitiesIdStringForRequest(cities: IdName[]) {
  let citiesString = '';

  cities.forEach(element => {
    citiesString += (element.id + '-');
  });

  citiesString = citiesString.slice(0, citiesString.length - 1);

  return citiesString;
}
