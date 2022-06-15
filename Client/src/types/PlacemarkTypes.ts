export interface IPlacemark {
    title: string;
    position: {
        latitude: number;
        longitude: number;
    };
    address: string;
    id?: number;
    type?: string;
}

export interface ITypedPlacemark extends IBasePlacemarkRequest {
    type: string;
}

export interface IEventPlacemark extends IBasePlacemarkRequest {
    startDate: string;
}

export interface IProposalPlacemark extends ITypedPlacemark {
    positiveVotesCount: number;
}

export interface IBasePlacemarkRequest extends IPlacemark {
    images: any[];
    description: string;
}

export interface IUnionRequestsType extends IBasePlacemarkRequest {
    type?: string;
    startTime?: string;
    endTime?: string;
}

export const colors: { [index: string]: string } = {
    administration: 'Crimson',
    other: 'grey',
    education: 'HotPink',
    production: 'Coral',
    sport: 'Gold',
    security: 'MediumSlateBlue',
    medicine: 'LightSkyBlue',
    culture: 'LawnGreen'
}

