export interface IPlacemark {
    id: number;
    name: string;
    coords: {
        latitude: number;
        longitude: number;
    };
    type: number;
}

export interface IFullPlacemark extends IPlacemark {
    description: string;
}

export interface ILayer {
    title: string;
    description: string;
}

