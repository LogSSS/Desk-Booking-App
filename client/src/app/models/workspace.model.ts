export enum WorkspaceType {
  OpenSpace = 0,
  PrivateRoom = 1,
  MeetingRoom = 2,
}

export interface MyImage {
  id: number;
  link: string;
  workspaceId: number;
}

export interface Amenity {
  id: number;
  iconContent: string;
}

export interface RoomAvailability {
  id: number;
  maxPeople: number;
  availableRooms: number;
}

export interface Capacity {
  id: number;
  roomAvailabilities: RoomAvailability[];
}

export interface Booking {
  id: number;
  roomSize: number;
  startDate: string;
  endDate: string;
}

export interface Workspace {
  id: number;
  name: string;
  type: WorkspaceType;
  images: MyImage[];
  description: string;
  amenities: Amenity[];
  capacityOptions: Capacity[];
  booked?: Booking | null;
}
