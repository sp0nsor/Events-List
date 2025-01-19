import axios from "axios";

export const fetchEvents = async (queryParams = {}) => {
  try {
    const params = new URLSearchParams();

    if (queryParams.SearchName)
      params.append("SearchName", queryParams.SearchName);
    if (queryParams.SearchPlace)
      params.append("SearchPlace", queryParams.SearchPlace);
    if (queryParams.SearchCategory)
      params.append("SearchCategory", queryParams.SearchCategory);
    if (queryParams.SortItem) params.append("SortItem", queryParams.SortItem);
    if (queryParams.SortOrder)
      params.append("SortOrder", queryParams.SortOrder);
    if (queryParams.Page) params.append("Page", queryParams.Page);
    if (queryParams.PageSize) params.append("PageSize", queryParams.PageSize);

    if (!queryParams.Page) params.append("Page", 1);
    if (!queryParams.PageSize) params.append("PageSize", 10);

    const response = await axios.get(
      `http://localhost:5078/Events?${params.toString()}`
    );

    return response.data;
  } catch (error) {
    console.error("Error fetching events:", error);
    throw error;
  }
};

export const createEvent = async (event) => {
  const formData = new FormData();

  formData.append("Name", event.name);
  formData.append("Description", event.description);
  formData.append("Place", event.place);
  formData.append("Category", event.category);
  formData.append("MaxParticipantCount", event.maxParticipantCount);
  formData.append("Date", event.date);

  if (event.image) {
    formData.append("Image", event.image);
  }

  try {
    const response = await axios.post(
      "http://localhost:5078/Events",
      formData,
      {
        headers: {
          Accept: "*/*",
          "Content-Type": "multipart/form-data",
        },
      }
    );

    return response.data;
  } catch (error) {
    console.error("Error creating event:", error);
    throw error;
  }
};
