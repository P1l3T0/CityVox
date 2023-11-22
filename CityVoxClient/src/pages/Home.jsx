import { TopNav } from "../components/navigation/TopNav";
import { useCallback, useEffect, useState } from "react";
import { styled } from "@mui/material/styles";
import useAuth from "../hooks/UseAuth";
import { useSelector } from "react-redux/es/hooks/useSelector";
import { useDispatch } from "react-redux";
import { SideNav } from "../components/navigation/SideNav";
import { useLocation } from "react-router-dom";
import MapView from "../components/MapView";
import RegionDropdown from "../components/dropdown/RegionDropdown";
import MunicipalityDropdown from "../components/dropdown/MunicipalityDropdown";
import { Grid, Box } from "@mui/material";

export const SIDE_NAV_WIDTH = 280;

export const LayoutRoot = styled("div")(({ theme }) => ({
  display: "flex",
  flex: "1 1 auto",
  maxWidth: "100%",
  [theme.breakpoints.up("lg")]: {
    paddingLeft: SIDE_NAV_WIDTH,
  },
}));

export const LayoutContainer = styled("div")({
  display: "flex",
  flex: "1 1 auto",
  flexDirection: "column",
  width: "100%",
});

const Home = () => {
  const appUser = useSelector((state) => state.user);

  const [selectedRegion, setSelectedRegion] = useState(null);
  const [selectedMunicipality, setSelectedMunicipality] = useState(null);

  const location = useLocation();
  const pathname = location.pathname;
  const [openNav, setOpenNav] = useState(false);

  const handleRegionChange = (selectedRegionId) => {
    setSelectedRegion(selectedRegionId);
  }

  const handlePathnameChange = useCallback(() => {
    if (openNav) {
      setOpenNav(false);
    }
  }, [openNav]);

  useEffect(
    () => {
      handlePathnameChange();
    },
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [pathname]
  );

  return (
    <>
      <TopNav onNavOpen={() => setOpenNav(true)} />
      <SideNav onClose={() => setOpenNav(false)} open={openNav} />
      <LayoutRoot>
        <LayoutContainer>
          <Grid container spacing={2} style={{ justifyContent: "flex-start" }} pl="1.5rem">
            <Grid item xs={12} sm={2} style={{ flexBasis: "33.33%" }}>
              <RegionDropdown onChange={handleRegionChange} />
            </Grid>
            <Grid item xs={12} sm={2} style={{ flexBasis: "33.33%" }}>
              <MunicipalityDropdown
                regionId={selectedRegion}
                onChange={setSelectedMunicipality}
              />
            </Grid>
          </Grid>
          <Box mt="1rem" p="1rem" width="100%" height={750} overflow="auto">
            <MapView selectedMunicipalityId={selectedMunicipality?.municipalityId} osmId={selectedMunicipality?.osmId} token={appUser.accessToken}/>
          </Box>
        </LayoutContainer>
      </LayoutRoot>
    </>
  );
};

export default Home;
