export enum WorkspaceType {
  OpenSpace = 0,
  PrivateRoom = 1,
  MeetingRoom = 2,
}

export interface MyImageDTO {
  id: number;
  link: string;
  workspaceId: number;
}

export interface BaseWorkspace {
  id: number;
  name: string;
  type: WorkspaceType;
  images: MyImageDTO[];
}

export interface Booking {
  id: number;
  ownerId: number;
  name: string;
  email: string;
  workspace: {
    id: number;
    name: string;
    type: WorkspaceType;
    images: MyImageDTO[];
  } | null;
  status: number;
  startDate: string;
  endDate: string;
  workspaceId: number;
  roomSize: number;
}

export interface BookingDTO {
  id: number;
  ownerId: number;
  name: string;
  email: string;
  workspace: BaseWorkspace | null;
  status: number;
  startDate: string;
  endDate: string;
  workspaceId: number;
  roomSize: number;
}

export interface UpsertBooking {
  name: string;
  email: string;
  startDate: string;
  endDate: string;
  workspaceId: number;
  roomSize: number;
  status: number;
  ownerId: number;
}
