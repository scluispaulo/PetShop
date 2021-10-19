import { Owner } from "./Owner";

export interface Pet {
  Id?: number;
  Name: string;
  ReasonForTreatment: string;
  HeathState: number;
  Image: string;
  OwnerId?: number;
  OwnerDTO?: Owner;
  AccommodationNumber: number;
}