export interface IPlacemark {
    id: number;
    name: string;
    coords: number[];
    type: string;
}

export interface IFullPlacemark extends IPlacemark {
    description: string;
}

