// GuideService.js
import axios from 'axios';
import { GUIDE_API } from './constants';

export const getGuideDetails = (guideId) => {
    return axios.get(GUIDE_API.DETAILS(guideId));
};

