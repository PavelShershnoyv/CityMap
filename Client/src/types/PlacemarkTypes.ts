export interface IPlacemark {
    title: string;
    position: {
        latitude: number;
        longitude: number;
    };
    address: string;
}

export interface ITypedPlacemark extends IPlacemark {
    type: string;
}

export interface IEventPlacemark extends IPlacemark {
    startDate: string;
}

export interface IProposalPlacemark extends IPlacemark {
    positiveVotesPercentage: number;
}

export interface IBasePlacemarkRequest extends IPlacemark {
    images: any[];
    description: string;
}

export interface ITypedPlacemarkRequest extends IBasePlacemarkRequest {
    type: string;
}

export interface IEventPlacemarkRequest extends IBasePlacemarkRequest {
    startTime: string;
    endTime: string;
}

export interface IUnionRequestsType extends IBasePlacemarkRequest {
    type?: string;
    startTime?: string;
    endTime?: string;
}

export const colors: { [index: string]: string } = {
    administration: 'red',
    other: 'grey',
    education: 'purple',
    production: 'orange',
    sport: 'yellow',
    security: 'blue',
    medicine: 'light-blue',
    culture: 'green'
}

