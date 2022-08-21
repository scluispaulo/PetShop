import { Owner } from "./Owner";

export interface Pet {
  id: number;
  name: string;
  reasonForTreatment: string;
  heathState: number;
  image: string;
  ownerId?: number;
  ownerDTO?: Owner;
  accommodationNumber: number;
}