import { AccommodationStateEnum } from "../enums/AccommodationStateEnum";

export interface Accommodation {
  id?: number;
  number: number;
  state: AccommodationStateEnum;
}