import React from 'react';
import {useParams} from 'react-router-dom';
import {DefaultPlacemarks} from "./DefaultPlacemarks";
import {PastPlacemarks} from "./PastPlacemarks";
import {ProposalPlacemarks} from "./ProposalPlacemarks";
import {Events} from "./Events";
import {UserPlacemarks} from './UserPlacemarks';

export const Placemarks: React.FC = () => {
    const {type} = useParams();

    if (type === 'present') {
        return <DefaultPlacemarks />
    }

    if (type === 'past') {
        return <PastPlacemarks />
    }

    if (type === 'proposals') {
        return <ProposalPlacemarks />
    }

    if (type === 'user') {
        return <UserPlacemarks />
    }

    return <Events />
}